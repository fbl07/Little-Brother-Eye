using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.DataAccess.DataAccessObjects
{
    public class CodeTables : BaseDataAccess
    {
        public CodeTable GetCodeTable(int codeTableId)
        {
            return Context.CodeTables.FirstOrDefault(x => x.CodeTableId == codeTableId);
        }
        
        public Dictionary<int, string> DropDownForCodeTable(Constants.CodeTables codeTable, bool Order = false, int? forceIncludeValue = null, bool includeDeleted = false)
        {
            var codes = Context.CodeValues.Where(x => x.CodeTableId == (int)codeTable);
            if (!includeDeleted)
                codes = codes.Where(x => !x.Deleted || (forceIncludeValue.HasValue && x.CodeValue1 == forceIncludeValue.Value));

            if (Order)
                codes = codes.OrderBy(x => x.Description);

            return codes.ToDictionary(x => x.CodeValue1, y => y.Description);
        }

        public CodeValue GetCodeValue(int codeValue)
        {
            return Context.CodeValues.FirstOrDefault(x => x.CodeValue1 == codeValue);
        } 

    }
}