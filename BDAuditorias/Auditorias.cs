using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Excepcoes;
using ObjetosAuditoria;
using System.Globalization;
/*  -------------------------------------------------
* <copyright file="Auditorias.cs" company="IPCA"/>
* <summary>
*	Trabalho Pratico LP2 2019-2020
*	José Dias       18840
*	Pedro Ferraz    18842
* </summary>
* <author>José Dias & Pedro Ferraz</author>
* <email
*   a18840@alunos.ipca.pt
*   a18842@alunos.ipca.pt
* </email>
* <desc>
*   Auditorias
* </desc>
* -------------------------------------------------
*/
namespace BDAuditorias
{
    [Serializable]
    public class Auditorias
    {
        #region Member Variables
        private static List<Auditoria> lstAuditorias;
        #endregion

        #region Constructors
        /// <summary>
        /// Construtor
        /// </summary>
        static Auditorias()
        {
            lstAuditorias = new List<Auditoria>();
        }
        #endregion

        #region Properties
        #endregion

        #region Functions
        /// <summary>
        /// Para devolver a auditoria com mais vulnerabilidades
        /// </summary>
        /// <param name="lstAud">Conjunto de todas as auditorias</param>
        /// <returns> Devolve a auditoria com mais vulnerabilidades </returns>
        public static Auditoria AuditoriaMaisVulnerabilidades()
        {
            Auditoria maisVuln = lstAuditorias[0];
            for (int i = 1; i < TotalAuditorias(); i++)
            {
                if (lstAuditorias[i].CodVulns.Count > maisVuln.CodVulns.Count)
                {
                    maisVuln = lstAuditorias[i];
                }
            }
            return maisVuln;
        }
        /// <summary>
        /// Para devolver a auditoria com menos vulnerabilidades
        /// </summary>
        /// <param name="lstAud">Conjunto de todas as auditorias</param>
        /// <returns> Devolve a auditoria com menos vulnerabilidades </returns>
        public static Auditoria AuditoriaMenosVulnerabilidades()
        {
            Auditoria menosVuln = lstAuditorias[0];
            for (int i = 1; i < TotalAuditorias(); i++)
            {
                if (lstAuditorias[i].CodVulns.Count < menosVuln.CodVulns.Count)
                {
                    menosVuln = lstAuditorias[i];
                }
            }
            return menosVuln;
        }
        /// <summary>
        /// Para devolver a media de vulnerabilidades nas auditorias
        /// </summary>
        /// <param name="lstAud">Conjunto de todas as auditorias</param>
        /// <returns> Devolve a media de vulnerabilidades nas auditorias </returns>
        public static float MediaVulnerabilidades()
        {
            try
            {
                int countVuln = 0;          //contador de vulnerabilidades
                for (int i = 0; i < TotalAuditorias(); i++)
                {
                    countVuln += lstAuditorias[i].CodVulns.Count;
                }
                return ((float)countVuln / TotalAuditorias());
            }
            catch (DivideByZeroException e)
            {
                throw new DivideByZeroException("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Adiciona uma auditoria a lista
        /// </summary>
        /// <param name="a">auditoria a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não a auditoria</returns>
        public static bool InsereAuditorias(Auditoria a)
        {
            try
            {
                if (!ProcuraAuditoria(a.Codigo))
                {
                    lstAuditorias.Add(a);
                    return true;
                }
                return false;
            }
            catch (AuditoriaInexistenteException e)
            {
                throw new AuditoriaInexistenteException("ERRO! " + e.Message);
            }
            catch (InsercaoException e)
            {
                throw new InsercaoException("ERRO! " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Verifica se já existe a auditoria
        /// </summary>
        /// <param name="codAuditoria">Codigo da auditoria</param>
        /// <returns> Devolve true/false consoante exista a auditoria</returns>
        public static Auditoria EncontraAuditoria(int codAuditoria)
        {
            int i = 0;
            for (; i < TotalAuditorias(); i++)
            {
                if (lstAuditorias[i].Codigo == codAuditoria) { return lstAuditorias[i]; }
            }
            return null;
        }
        /// <summary>
        /// Calcula o numero total de auditorias
        /// </summary>
        /// <returns> numero total de auditorias </returns>
        public static int TotalAuditorias()
        {
            return lstAuditorias.Count;
        }
        /// <summary>
        /// Retira uma vulnerabilidade de uma auditoria
        /// </summary>
        /// <param name="codVuln">Codigo da vulnerabilidade</param>
        /// <returns> Devolve true/false </returns>
        public static bool RemoveVulnerabilidadeAuditoria(int codVuln)
        {
            int i = 0; int j = 0;
            for (; i < TotalAuditorias(); i++)
            {
                for (; j < lstAuditorias[i].CodVulns.Count; j++)
                {
                    if (lstAuditorias[i].CodVulns[j] == codVuln) { lstAuditorias[i].CodVulns.RemoveAt(j); }
                }
            }
            return true;
        }
        #endregion

        #region Verification
        /// <summary>
        /// Verifica se já existe a auditoria
        /// </summary>
        /// <param name="codAuditoria">Codigo da auditoria</param>
        /// <returns> Devolve true/false consoante exista a auditoria</returns>
        public static bool ProcuraAuditoria(int codAuditoria)
        {
            int i = 0;
            for (; i < TotalAuditorias(); i++)
            {
                if (lstAuditorias[i].Codigo == codAuditoria){ return true; }
            }
            return false;
        }
        /// <summary>
        /// Apresenta todas auditorias feitas
        /// </summary>
        public static void ApresentarAuditorias()
        {
            int i = 0;
            Console.WriteLine("=======================================Auditorias=============================================");
            Console.WriteLine(" {0,-7}|{1,-15}|{2,-10}|{3,-17}|{4,-10}","Código","Data","Duração","Cod. Colaborador","Nº vulnerabilidades");
            for (; i < TotalAuditorias(); i++)
            {
                Console.WriteLine(" {0}",lstAuditorias[i].ToString());
            }
        }
        /// <summary>
        /// Apresenta todas as vulnerabilidades presentes nas auditorias feitas
        /// </summary>
        public static void ApresentarVulneabilidadesAuditoria()
        {
            int i = 0;
            int j = 0;
            for (; i < TotalAuditorias(); i++)
            {
                Console.WriteLine("");
                Console.WriteLine(" Auditoria : {0}\n {1,-12}|{2,-30}|{3,-10}", lstAuditorias[i].Codigo.ToString(),"Codigo Vuln.","Descrição","Nível");
                if (lstAuditorias[i].CodVulns.Count == 0) { Console.WriteLine("\tNão contem vulnerabilidades"); }
                else
                { 
                    for (; j < lstAuditorias[i].CodVulns.Count; j++)
                    {
                        Vulnerabilidade aux = Vulnerabilidades.EncontraVulnerabilidade(lstAuditorias[i].CodVulns[j]);
                        Console.WriteLine(" {0,-12}|{1,-30}|{2,-10}", aux.Codigo.ToString(),aux.Descricao,aux.Nivel.ToString());
                    }
                }
            }
        }
        #endregion

        #region File
        /// <summary>
        /// Guarda os documentos num ficheiro binario
        /// </summary>
        /// <param name="fileName">ficheiro</param>
        public static bool Save(string fileAuditorias)
        {
            try
            {
                Stream s = File.Open(fileAuditorias, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, lstAuditorias);
                s.Flush();
                s.Close();
                s.Dispose();
                return true;
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("Erro: " + e.Message);
            }
            catch (IOException e)
            {
                throw new IOException("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Carrega os documentos de um ficheiro binario
        /// </summary>
        /// <param name="fileName">ficheiro</param>
        public static bool Load(string fileAuditorias)
        {
            try
            {
                Stream s = File.Open(fileAuditorias, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                lstAuditorias = (List<Auditoria>)b.Deserialize(s);
                s.Flush();
                s.Close();
                s.Dispose();
                return true;
            }
            catch (FileLoadException e)
            {
                throw new FileLoadException("Erro: " + e.Message);
            }
            catch (IOException e)
            {
                throw new IOException("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        #endregion

        #region Destructor
        ~Auditorias() { }
        #endregion


        #region Enums
        #endregion
    }
}
