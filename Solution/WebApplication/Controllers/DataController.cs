using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication.Modules;

namespace WebApplication.Controllers
{
    public class DataController : Controller
    {
        private ArrayList list;
        [Route("api/Select")]
        [HttpGet]
        public ArrayList Select()
        {
            list = new ArrayList();

            DataBase db = new DataBase();
            MySqlDataReader mdr = db.GetReader("select * from Notice");

            while (mdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < mdr.FieldCount; i++)
                {
                    ht.Add(mdr.GetName(i), mdr.GetValue(i));
                }
                list.Add(ht);
            }

            mdr.Close();
            db.ConnectionClose();
            return list;
        }

    }
}
