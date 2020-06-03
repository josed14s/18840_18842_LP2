using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Excepcoes;
using ObjetosAuditoria;
/*  -------------------------------------------------
* <copyright file="Vulnerabilidades.cs" company="IPCA"/>
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
*   Vulnerabilidades
* </desc>
* -------------------------------------------------
*/
namespace BDAuditorias
{
    [Serializable]
    public class Vulnerabilidades
    {
        #region Member Variables
        private static List<Vulnerabilidade> lstVulnerabilidades;
        #endregion

        #region Constructors
        /// <summary>
        /// Construtor
        /// </summary>
        static Vulnerabilidades()
        {
            lstVulnerabilidades = new List<Vulnerabilidade>();
        }
        #endregion

        #region Properties
        #endregion

        #region Functions
        /// <summary>
        /// Calcula o numero total de vulnerabilidades
        /// </summary>
        /// <returns> numero total de vulnerabilidades </returns>
        public static int TotalVulnerabilidades()
        {
            return lstVulnerabilidades.Count;
        }
        /// <summary>
        /// Verifica se já existe a vulnerabilidade
        /// </summary>
        /// <param name="codVulnerabilidade">Codigo da vulnerabilidade</param>
        /// <returns> Devolve true/false consoante exista a vulnerabilidade</returns>
        public static bool ProcuraVulnerabilidade(int codVulnerabilidade)
        {
            int i = 0;
            for (; i < TotalVulnerabilidades(); i++)
            {
                if (lstVulnerabilidades[i].Codigo == codVulnerabilidade) { return true; }
            }
            return false;
        }
        /// <summary>
        /// Verifica se já existe a vulnerabilidade e devolve-a
        /// </summary>
        /// <param name="codVulnerabilidade">Codigo da vulnerabilidade</param>
        /// <returns> Devolve a vulnerabilidade desejada</returns>
        public static Vulnerabilidade EncontraVulnerabilidade(int codVulnerabilidade)
        {
            int i = 0;
            for (; i < TotalVulnerabilidades(); i++)
            {
                if (lstVulnerabilidades[i].Codigo == codVulnerabilidade) { return lstVulnerabilidades[i]; }
            }
            return null;
        }
        /// <summary>
        /// Adiciona uma vulnerabilidade a lista
        /// </summary>
        /// <param name="vuln">vulnerabilidade a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não uma vulnerabilidade</returns>
        public static bool InsereVulnerabilidades(Vulnerabilidade vuln)
        {
            try
            {
                lstVulnerabilidades.Add(vuln);
                return true;
            }
            catch (VulnerabilidadeInexistenteException e)
            {
                throw new VulnerabilidadeInexistenteException("ERRO! " + e.Message);
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
        /// Apresenta todas vulnerabilidades encontradas
        /// </summary>
        public static void ApresentarVulnerabilidades()
        {
            int i = 0;
            Console.WriteLine("=======================================Vulnerabilidades========================================");
            Console.WriteLine(" {0,-7}|{1,-30}|{2,-10}|{3,-20}|{4,-15}|{5,-10}", "Código", "Descrição", "Nível","Nº Equipamentos", "Nº Auditorias", "Resolvida?");
            for (; i < TotalVulnerabilidades(); i++)
            {
                Console.WriteLine(" {0}", lstVulnerabilidades[i].ToString());
            }
        }
        #endregion

        #region File
        /// <summary>
        /// Guarda os dados num ficheiro binario
        /// </summary>
        /// <param name="fileVulnerabilidades">ficheiro</param>
        public static bool Save(string fileVulnerabilidades)
        {
            try
            {
                Stream s = File.Open(fileVulnerabilidades, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, lstVulnerabilidades);
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
        /// Carrega os dados de um ficheiro binario
        /// </summary>
        /// <param name="fileVulnerabilidades">ficheiro</param>
        public static bool Load(string fileVulnerabilidades)
        {
            try
            {
                Stream s = File.Open(fileVulnerabilidades, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                lstVulnerabilidades = (List<Vulnerabilidade>)b.Deserialize(s);
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
        ~Vulnerabilidades() { }
        #endregion

        #region Enums
        #endregion
    }
}
