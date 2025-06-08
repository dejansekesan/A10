using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace A10
{
    class Pecaros
    {
        public int PecarosID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public int GradID { get; set; }
        public string Grad { get; set; }
        public string Telefon { get; set; }
        public string Message { get; set; }

        public string Prikaz
        {
            get { return this.ToString(); }
        }

        public override string ToString()
        {
            return String.Format("{0,-6}{1,-15}{2,-15}{3,-20}{4,-15}{5,-12}", this.PecarosID, this.Ime, this.Prezime, this.Adresa, this.Grad, this.Telefon); ;
        }

        public Pecaros() { }

        public Pecaros(DataRow dr)
        {
            this.InicijalizujPolja(dr);
        }

        public void InicijalizujPolja(DataRow dr)
        {
            this.PecarosID = (int)dr["PecarosID"];
            this.Ime = (string)dr["Ime"];
            this.Prezime = (string)dr["Prezime"];
            if (dr["Adresa"] != DBNull.Value)
                this.Adresa = (string)dr["Adresa"];
            this.GradID = (int)dr["GradID"];
            if (dr["Grad"] != DBNull.Value)
                this.Grad = (string)dr["Grad"];
            if (dr["Telefon"] != DBNull.Value)
                this.Telefon = (string)dr["Telefon"];
        }

        public static List<Pecaros> UcitajSve()
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Pecaros";
            cmd.Parameters.AddWithValue("@akcija", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Pecaros> lista = new List<Pecaros>();
            try
            {
                cmd.Connection.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                        lista.Add(new Pecaros(dr));
                    return lista;
                }
                else
                    throw new Exception("Desila se greška ili je tabela prazna");
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public Pecaros(int sifra)
        {
            this.PecarosID = sifra;
            if (!this.Ucitaj())
                throw new Exception(this.Message);
        }

        public bool Ucitaj()
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Pecaros";
            cmd.Parameters.AddWithValue("@akcija", 0);
            cmd.Parameters.AddWithValue("@sifra", this.PecarosID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    this.InicijalizujPolja(dt.Rows[0]);
                    return true;
                }
                else
                    throw new Exception("Podatak nije pronađen");
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public bool Izmeni()
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Pecaros";
            cmd.Parameters.AddWithValue("@akcija", 1);
            cmd.Parameters.AddWithValue("@sifra", this.PecarosID);
            cmd.Parameters.AddWithValue("@ime", this.Ime);
            cmd.Parameters.AddWithValue("@prezime", this.Prezime);
            cmd.Parameters.AddWithValue("@adresa", this.Adresa);
            cmd.Parameters.AddWithValue("@gradid", this.GradID);
            cmd.Parameters.AddWithValue("@telefon", this.Telefon);
            try
            {
                cmd.Connection.Open();
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
                else
                    throw new Exception("Podatak nije izmenjen!");
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public string PrikazPecarosa
        {
            get { return this.PecarosID + "-" + this.Ime + " " + this.Prezime; }
        }

        public static DataTable Statistika(int sifra, DateTime godinaOd, DateTime godinaDo)
        {
            SqlCommand cmd = Konekcija.GetCommand();
            cmd.CommandText = "usp_Pecaros";
            cmd.Parameters.AddWithValue("@akcija", 2);
            cmd.Parameters.AddWithValue("@sifra", sifra);
            cmd.Parameters.AddWithValue("@od", godinaOd);
            cmd.Parameters.AddWithValue("@do", godinaDo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    throw new Exception("Nisu nadjeni podaci");
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}