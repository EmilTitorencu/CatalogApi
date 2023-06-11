using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AccessLayer
{
    public partial class AccessLayer : IAccessLayer
    {
        public Curs AddCurs(Curs curs)
        {
            ctx.Cursuri.Add(curs);
            ctx.SaveChanges();
            return curs;
        }
        public List<Curs> GetAllCursuri() =>
            ctx.Cursuri.ToList();
    }
}
