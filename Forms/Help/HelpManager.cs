using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlHelp;
using HtmlHelp.ChmDecoding;
using HtmlHelp.UIComponents;

namespace DMS.Forms.DocumentForms
{
    public class HelpManager
    {
        HtmlHelpSystem _reader = new HtmlHelpSystem();
        DumpingInfo _dmpInfo = null;
        InfoTypeCategoryFilter _filter = new InfoTypeCategoryFilter();

        string _prefDumpOutput = "";

        DumpCompression _prefDumpCompression = DumpCompression.Medium;

        DumpingFlags _prefDumpFlags = DumpingFlags.DumpBinaryTOC | DumpingFlags.DumpTextTOC |
            DumpingFlags.DumpTextIndex | DumpingFlags.DumpBinaryIndex |
            DumpingFlags.DumpUrlStr | DumpingFlags.DumpStrings;

        string _prefURLPrefix = "mk:@MSITStore:";
        bool _prefUseHH2TreePics = false;

        public HelpManager(string fileName)
        {
            try
            {
                _reader.OpenFile(fileName, _dmpInfo);
            }
            catch { }
        }
        public HtmlHelpSystem Reader
        {
            get
            {
                return _reader;
            }
        }

    }
}
