using APISample.Interface;
using APISample.Models;

namespace APISample.Sevices
{
    public class SVehicleType : IVehicleType
    {
        private readonly DatabaseContext db;
        public SVehicleType(DatabaseContext db)
        {
            this.db = db;
        }

        public int? Create(VehicleType VT)
        {
            try
            {
                if (VT != null)
                {
                    db.SM_VehicleType_Mst.Add(VT);
                    if (db.SaveChanges() > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
            return null;
        }

        public int? Update(int id, VehicleType VT)
        {
            try
            {
                VehicleType? _VT = db.SM_VehicleType_Mst.Find(id);
                if (_VT != null)
                {
                    _VT.VehicleCategory = VT.VehicleCategory;
                    _VT.Remark = VT.Remark;
                    _VT.IaActive = VT.IaActive;

                    db.SM_VehicleType_Mst.Update(_VT);
                    if (db.SaveChanges() > 0)
                    {
                        return 1;
                    }
                    else { return 0; }
                }
            }
            catch (Exception ex) { return -1; }
            return null;

        }

        public int? DeleteOne(int id)
        {
            try
            {
                VehicleType? VT = db.SM_VehicleType_Mst.Find(id);
                if (VT != null)
                {
                    db.SM_VehicleType_Mst.Remove(VT);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex) { return -1; }
        }

        public List<VehicleType>? GetAll()
        {
            try
            {
                List<VehicleType> VT = db.SM_VehicleType_Mst.ToList();
                if (VT != null)
                {
                    return VT;
                }

            }
            catch (Exception ex) { }
            return null;
        }
    }
}
