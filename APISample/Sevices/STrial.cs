using APISample.Interface;
using APISample.Models;
namespace APISample.Sevices
{
    //public class STrial
    //{
    //    /// <summary>
    //    /// Insert data into table using this type of code
    //    /// </summary>
    //    /// <param name="TC">Model class </param>
    //    /// <param name="DB">Database object</param>
    //    /// <returns></returns>
    //    public int Save(TrialClass TC, DatabaseContext DB)
    //    {
    //        DB.SM_TrialClass_Mst.Add(TC);
    //        if (DB.SaveChanges() > 0)
    //        {
    //            return 1;
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //}

    public class STrial : ITrial
    {
        private readonly DatabaseContext DB;
        public STrial(DatabaseContext _databaseContext)
        {
                this.DB = _databaseContext;
        }
        public int Save(TrialClass TC)
        {
            DB.SM_TrialClass_Mst.Add(TC);
            if (DB.SaveChanges() > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int DeleteOne(int id)
        {
            TrialClass? TC = DB.SM_TrialClass_Mst.Find(id);
            if (TC != null)
            {
                DB.Remove(TC);
                if(DB.SaveChanges() > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
        public List<TrialClass> GetAll()
        {
           List<TrialClass> TC =  DB.SM_TrialClass_Mst.ToList();
           return TC;
        }

        public int Update(int id, TrialClass tc)
        {
            TrialClass? TC = DB.SM_TrialClass_Mst.Find(id);
            if (TC != null)
            {
                TC.Name = tc.Name;
                TC.Email = tc.Email;
                TC.Contact = tc.Contact;
                TC.Address = tc.Address;

                DB.SM_TrialClass_Mst.Update(TC);
                if(DB.SaveChanges() > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
