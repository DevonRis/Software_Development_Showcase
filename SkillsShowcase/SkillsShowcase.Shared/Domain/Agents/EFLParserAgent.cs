using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace SkillsShowcase.Shared.Domain.Agents
{
    public static class EFLParserAgent
    {
        public static string GetPdfFileContent(Stream stream)
        {
            stream.Position = 0;

            var memoryStream = new MemoryStream();

            stream.CopyTo(memoryStream);

            return GetPdfFileContent(memoryStream);
        }
        public static List<decimal> ExtractKwhPrices(string pdfContent)
        {
            List<decimal> prices = new List<decimal>();

            // Add Patterns as you go
            var regexPatterns = new[]
            {
                @"Average (?:Monthly )?Use[:\s]*500\s*kWh\s*(\d+(\.\d+)?)\s*¢?\s*1000\s*kWh\s*(\d+(\.\d+)?)\s*¢?\s*2000\s*kWh\s*(\d+(\.\d+)?)\s*¢?",
                @"Average\s*Price\s*per\s*kWh\s*:?\s*(\d+(\.\d+)?)\s*¢?\s*(\d+(\.\d+)?)\s*¢?\s*(\d+(\.\d+)?)\s*¢?",
                @"Average Price per kWh\s*[\n\r\s]*500\s*kWh\s*([\d.]+)\s*¢?\s*[\n\r\s]*1000\s*kWh\s*([\d.]+)\s*¢?\s*[\n\r\s]*2000\s*kWh\s*([\d.]+)\s*¢?",
                @"Average Price\s*per kWh\s*:?[\s\S]*?(\d+(\.\d+)?)¢?\s+(\d+(\.\d+)?)¢?\s+(\d+(\.\d+)?)¢?",
                @"Average price \(per kWh\)\s*:?[\s\S]*?(\d+(\.\d+)?)¢?\s+(\d+(\.\d+)?)¢?\s+(\d+(\.\d+)?)¢?",
                @"Average price per kWh\s*:?[\s\S]*?(\d+(\.\d+)?)¢?\s+(\d+(\.\d+)?)¢?\s+(\d+(\.\d+)?)¢?",
                @"Average Price\s*per kWh\s*([\d.]+)\s*¢?\s+([\d.]+)\s*¢?\s+([\d.]+)\s*¢?",
                @"Average Monthly Use\s*500 kWh\s*(\d+(\.\d+)?)¢?\s*1000 kWh\s*(\d+(\.\d+)?)¢?\s*2000 kWh\s*(\d+(\.\d+)?)¢?",
                @"Average Price per kWh\s*500 kWh\s*(\d+(\.\d+)?)¢?\s*1000 kWh\s*(\d+(\.\d+)?)¢?\s*2000 kWh\s*(\d+(\.\d+)?)¢?",
                @"Average Price per kWh\s*500 kWh\s*([\d.]+)\s*¢?\s*1000 kWh\s*([\d.]+)\s*¢?\s*2000 kWh\s*([\d.]+)\s*¢?",
                @"Average\s*(?:Monthly\s*)?Price\s*per\s*kWh\s*:?\s*(\d+(\.\d+)?)¢?\s+(\d+(\.\d+)?)¢?\s+(\d+(\.\d+)?)¢?",
                @"Average\s*Price\s*per\s*kWh\s*:?\s*(\d+(\.\d+)?)¢?\s*(\d+(\.\d+)?)¢?\s*(\d+(\.\d+)?)¢?",
                @"500\s*kWh\s*1,000\s*kWh\s*2,000\s*kWh\s*(\d+(\.\d+)?)¢?\s*(\d+(\.\d+)?)¢?\s*(\d+(\.\d+)?)¢?",
                @"500\s*kWh:\s*(\d+(\.\d+)?)¢?\s*\|\s*1000\s*kWh:\s*(\d+(\.\d+)?)¢?\s*\|\s*2000\s*kWh:\s*(\d+(\.\d+)?)¢?",
                @"500kWh\s*(\d+(\.\d+)?)¢?,?\s*1000kWh\s*(\d+(\.\d+)?)¢?,?\s*2000kWh\s*(\d+(\.\d+)?)¢?",
            };
            foreach (var pattern in regexPatterns)
            {
                var match = Regex.Match(pdfContent, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    prices.Add(decimal.Parse(match.Groups[1].Value.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture) / 100);
                    prices.Add(decimal.Parse(match.Groups[3].Value.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture) / 100);
                    prices.Add(decimal.Parse(match.Groups[5].Value.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture) / 100);
                    break;
                }
            }
            return prices;
        }
        public static int ExtractLengthOfTerm(string pdfContent)
        {
            // Add Patterns as you go
            var regexPatterns = new[]
            {
                @"Contract Length[:\s]*?(\d+)\s*Months?",
                @"Contract Duration\s*:?[\s\S]*?(\d+)\s*Months?",
                @"Plan Term[:\s]*?(\d+)\s*Months?",
                @"Contract Term\s*:?[\s\S]*?(\d+)\s*Months?",
                @"Term\s*:?[\s\S]*?(\d+)\s*Months?",
                @"Contract Term:\s*(\d+)\s*Months?",
                @"Contract Term\s*:?[\s\S]*?(\d+)\s*Month",
                @"Contract Term\s*:?[\s\S]*?(\d+)\s*month"
            };
            foreach (var pattern in regexPatterns)
            {
                var match = Regex.Match(pdfContent, pattern, RegexOptions.IgnoreCase);
                if (match.Success && int.TryParse(match.Groups[1].Value, out int lengthOfTerm))
                {
                    return lengthOfTerm;
                }
            }
            return 0;
        }
        public static int GetREPIdFromEFLContent(string eflContent)
        {
            eflContent = eflContent.ToLower();

            var repDictionary = new Dictionary<string, int>
            {
                { "breeze", 8 },
                { "brilliant energy", 9 },
                { "champion energy", 11 },
                { "discount", 195 },
                { "green mountain", 25 },
                { "our energy", 34 },
                { "pennywise", 35 },
                { "reliant", 38 },
                { "southwest power and light", 41 },
                { "spark energy", 42 },
                { "startex", 43 },
                { "summer energy", 45 },
                { "gexa", 59 },
                { "think energy", 151 },
                { "pioneer", 64 },
                { "chariot energy", 197 },
                { "cleansky", 210 },
                { "acacia energy", 16 },
                { "direct energy", 17 },
                { "frontier utilities", 24 },
                { "just energy", 29 },
                { "mission power", 31 },
                { "nec retail", 32 },
                { "new leaf energy", 33 },
                { "stream energy", 44 },
                { "texpo energy", 48 },
                { "true electric", 50 },
                { "txu energy", 52 },
                { "verge energy", 152 },
                { "viridian energy", 153 },
                { "volt electricity provider", 154 },
                { "nextera energy", 106 },
                { "xoom energy", 141 },
                { "tesla electric", 253 },
                { "octopus energy", 222 },
                { "4change energy", 2 },
                { "ambit energy", 3 },
                { "amigo energy", 4 },
                { "andeler power", 5 },
                { "ap gas & electric", 6 },
                { "apna energy", 7 },
                { "bounce energy", 8 },
                { "cirro energy", 12 },
                { "compassion energy", 13 },
                { "constellation new energy", 14 },
                { "cpl retail energy", 15 },
                { "american light & power", 18 },
                { "discount power (voltera)", 19 },
                { "encoa", 20 },
                { "entrust energy", 21 },
                { "everything energy", 22 },
                { "first choice power", 23 },
                { "hino electric power company", 27 },
                { "igs energy", 28 },
                { "kona energy", 30 },
                { "reach energy", 37 },
                { "smart prepaid electric", 39 },
                { "source power & gas", 40 },
                { "texas power", 47 },
                { "trusmart energy", 51 },
                { "v247 power corporation", 53 },
                { "veteran energy (vbb)", 54 },
                { "wtu retail energy", 55 },
                { "gb power", 56 },
                { "yep", 57 },
                { "zip energy", 58 },
                { "beyond power", 60 },
                { "clearview energy", 61 },
                { "conservice energy", 62 },
                { "enertrade electric", 63 },
                { "glacial energy", 65 },
                { "10k energy", 66 },
                { "aep energy", 67 },
                { "alliance power company", 68 },
                { "alltex power and light", 69 },
                { "gdf suez retail energy solutions", 70 },
                { "american xp", 71 },
                { "ameripower", 72 },
                { "assurance energy", 73 },
                { "bluestar energy solutions", 74 },
                { "bp energy company", 75 },
                { "bubba power", 76 },
                { "calpine power america", 77 },
                { "consolidated edison solutions", 78 },
                { "devonshire energy", 79 },
                { "dte energy supply", 80 },
                { "dynowatt", 81 },
                { "eagle energy", 82 },
                { "edf energy services", 83 },
                { "energy plus holdings", 85 },
                { "energy.me", 86 },
                { "expert energy", 87 },
                { "galt power texas", 88 },
                { "hudson energy services", 99 },
                { "iron energy", 94 },
                { "liberty power corp", 96 },
                { "budget power", 264 }
            };
            foreach (var rep in repDictionary)
            {
                if (eflContent.Contains(rep.Key))
                {
                    return rep.Value;
                }
            }
            return 0;
        }

        public static int GetTdspIdFromEFLContent(string eflContent)
        {
            var tdspDictionary = new Dictionary<string, int>
            {
                { "Unknown", 0 },
                { "Centerpoint Energy", 1 },
                { "Oncor", 2 },
                { "Texas New Mexico Power Energy", 4 },
                { "AEP Texas Central", 5 },
                { "AEP Texas North", 7 },
                { "Entergy Gulf States", 9 },
                { "Nueces Electric Coop", 158 },
                { "Sharyland Utilities McAllen", 133 },
                { "Sharyland Utilities Brady", 189 },
                { "Lubbock Power & Light", 190 }
            };
            foreach (var tdsp in tdspDictionary)
            {
                if (eflContent.Contains(tdsp.Key))
                {
                    return tdsp.Value;
                }
            }
            return 0;
        }
    }
}
