using CsvHelper.Configuration;
using Galytix.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace Galytix.WebApi.Mappers
{
     class GwpMap : CsvMapping<Gwp>
    {
        public GwpMap():base()
        {
            MapProperty(0,x => x.country);
            MapProperty(1,x => x.variableId);
            MapProperty(2,x => x.variableName);
            MapProperty(3,x => x.lineOfBusiness);
            MapProperty(4,x => x.Y2000);
            MapProperty(5,x => x.Y2001);
            MapProperty(6,x => x.Y2002);
            MapProperty(7,x => x.Y2003);
            MapProperty(8,x => x.Y2004);
            MapProperty(9,x => x.Y2005);
            MapProperty(10,x => x.Y2006);
            MapProperty(11,x => x.Y2007);
            MapProperty(12,x => x.Y2008);
            MapProperty(13,x => x.Y2009);
            MapProperty(14,x => x.Y2010);
            MapProperty(15,x => x.Y2011);
            MapProperty(16,x => x.Y2012);
            MapProperty(17,x => x.Y2013);
            MapProperty(18,x => x.Y2014);
            MapProperty(19,x => x.Y2015);
        }
    }
}
