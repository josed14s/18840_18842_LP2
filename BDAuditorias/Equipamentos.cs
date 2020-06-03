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
* <copyright file="Equipamentos.cs" company="IPCA"/>
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
*   Equipamentos
* </desc>
* -------------------------------------------------
*/
namespace BDAuditorias
{
    [Serializable]
    public class Equipamentos
    {
        #region Member Variables
        private static List<Equipamento> lstEquipamentos;
        #endregion

        #region Constructors
        static Equipamentos()
        {
            lstEquipamentos = new List<Equipamento>();
        }
        #endregion

        #region Properties
        #endregion

        #region Functions
        /// <summary>
        /// Calcula o numero total de equipamentos
        /// </summary>
        /// <returns> numero total de equipamentos </returns>
        public static int TotalEquipamentos()
        {
            return lstEquipamentos.Count;
        }
        /// <summary>
        /// Adiciona um equipamento a lista
        /// </summary>
        /// <param name="col">colaborador a ser adicionado</param>
        /// <returns> Devolve true/false consoante adicione ou não o colaborador</returns>
        public static bool InsereEquipamentos(Equipamento equip)
        {
            try
            {
                if (!ProcuraEquipamento(equip.Codigo))
                {
                    lstEquipamentos.Add(equip);
                    return true;
                }
                return false;
            }
            catch (ColaboradorInexistenteException e)
            {
                throw new ColaboradorInexistenteException("ERRO! " + e.Message);
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
        /// Verifica se já existe o equipamento
        /// </summary>
        /// <param name="codEquipamento">Codigo do Equipamento</param>
        /// <returns> Devolve true/false consoante exista o equipamento</returns>
        public static bool ProcuraEquipamento(int codEquipamento)
        {
            int i = 0;
            for (; i < TotalEquipamentos(); i++)
            {
                if (lstEquipamentos[i].Codigo == codEquipamento) { return true; }
            }
            return false;
        }
        /// <summary>
        /// Retira uma vulnerabilidade de um equipamento
        /// </summary>
        /// <param name="codVuln">Codigo da vulnerabilidade</param>
        /// <returns> Devolve true/false</returns>
        public static bool RemoveVulnerabilidadeEquipamento(int codVuln)
        {
            int i = 0; int j = 0;
            for (; i < TotalEquipamentos(); i++)
            {
                for (; j < lstEquipamentos[i].CodVulns.Count; j++)
                {
                    if (lstEquipamentos[i].CodVulns[j] == codVuln) { lstEquipamentos[i].CodVulns.RemoveAt(j); }
                }
            }
            return true;
        }
        /// <summary>
        /// Apresenta todos equipamentos encontrados
        /// </summary>
        public static void ApresentarEquipamentos()
        {
            int i = 0;
            Console.WriteLine("=======================================Equipamentos============================================");
            Console.WriteLine(" {0,-7}|{1,-15}|{2,-14}|{3,-15}|{4,-20}|{5,-15}", "Código", "Tipo", "Marca", "Modelo", "Data Aquisição", "Nº Vulnerabilidades");
            for (; i < TotalEquipamentos(); i++)
            {
                Console.WriteLine(" {0}", lstEquipamentos[i].ToString());
            }
        }
        #endregion

        #region File
        /// <summary>
        /// Guarda os documentos num ficheiro binario
        /// </summary>
        /// <param name="fileName">ficheiro</param>
        public static bool Save(string fileEquipamentos)
        {
            try
            {
                Stream s = File.Open(fileEquipamentos, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, lstEquipamentos);
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
        public static bool Load(string fileEquipamentos)
        {
            try
            {
                Stream s = File.Open(fileEquipamentos, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                lstEquipamentos = (List<Equipamento>)b.Deserialize(s);
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
        ~Equipamentos() { }
        #endregion

        #region Enums
        #endregion
    }
}
