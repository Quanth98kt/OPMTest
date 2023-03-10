using OPM.DBHandler;
using System.Collections.Generic;
using System.Data;

namespace OPM.OPMEnginee
{
    class CatalogAdmin
    {
        public static List<string> PathToContractNodeFromCurrentNode(string nameOfCurrentNode, DataTable table)
        {
            if (table.Rows.Count < 1) return null;
            List<string> list = new List<string>();
            string nameOfParentNode = nameOfCurrentNode;
            do
            {
                list.Add(nameOfParentNode);
                DataRow[] rows = table.Select(string.Format(@"ctlId = '{0}'", nameOfCurrentNode), "ctlname");
                if (rows[0]["ctlParent"].ToString() != null)
                {
                    nameOfParentNode = rows[0]["ctlParent"].ToString();
                }
                
                nameOfCurrentNode = nameOfParentNode;
            } while (nameOfParentNode != "");
            return list;
        }

        public static DataTable Table()
        {
            string query = string.Format("(SELECT ('Contract_'+ContractId)AS ctlId, ContractId AS ctlName, null AS ctlParent FROM dbo.Contract) UNION (SELECT 'PO_'+POId,POName, 'Contract_'+ContractId FROM dbo.PO) UNION (SELECT 'NTKT_'+NTKTId,'NTKT '+ NTKTPhase,'PO_'+POId FROM dbo.NTKT) UNION (SELECT 'DP_'+DPId,'DP '+DPId,'PO_'+POId FROM dbo.DP) UNION (SELECT 'PL_'+PLId,'PL '+ VNPTId + IIF(PLCheckMainLine = 1, ' - HC', ' - HDP'),'DP_'+DPId FROM dbo.PL) ORDER BY ContractId");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            DataTable table1 = new DataTable();
            table1.Columns.Add("ctlId");
            table1.Columns.Add("ctlName");
            table1.Columns.Add("ctlParent");
            return (table.Rows.Count > 0) ? table : table1;
        }

        public static DataTable searchTable(string txtsearch)
        {
            string query = string.Format("(SELECT ('Contract_'+ContractId) AS ctlId, ContractId AS ctlName, null AS ctlParent FROM dbo.Contract where ContractId like '%{0}%') UNION (SELECT 'PO_' + POId, POName, 'Contract_' + ContractId FROM dbo.PO ) UNION (SELECT 'NTKT_' + NTKTId, 'NTKT ' + NTKTPhase, 'PO_' + POId FROM dbo.NTKT) UNION (SELECT 'DP_' + DPId, 'DP ' + DPId, 'PO_' + POId FROM dbo.DP) UNION (SELECT 'PL_' + PLId, 'PL ' + VNPTId + IIF(PLCheckMainLine = 1, ' - HC', ' - HDP'), 'DP_' + DPId FROM dbo.PL) ORDER BY ContractId", txtsearch);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            DataTable table1 = new DataTable();
            table1.Columns.Add("ctlId");
            table1.Columns.Add("ctlName");
            table1.Columns.Add("ctlParent");
            return (table.Rows.Count > 0) ? table : table1;
        }
    }
}
