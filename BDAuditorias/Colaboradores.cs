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
* <copyright file="Colaboradores.cs" company="IPCA"/>
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
*   Colaboradores
* </desc>
* -------------------------------------------------
*/
namespace BDAuditorias
{
    [Serializable]
    public class Colaboradores
    {
        #region Member Variables
        private static List<Colaborador> lstColaboradores;
        #endregion

        #region Constructors
        static Colaboradores()
        {
            lstColaboradores = new List<Colaborador>();
        }
        #endregion

        #region Properties
        #endregion

        #region Function
        /// <summary>
        /// Verifica se já existe o colaborador e devolve-o
        /// </summary>
        /// <param name="codColaborador">Codigo da auditoria</param>
        /// <returns> Devolve o colaborador consoante exista na auditoria</returns>
        public static Colaborador EncontraColaborador(int codColaborador)
        {
            int i = 0;
            for (; i < TotalColaboradores(); i++)
            {
                if (lstColaboradores[i].Codigo == codColaborador) { return lstColaboradores[i]; }
            }
            return null;
        }
        /// <summary>
        /// Calcula o numero total de colaboradores
        /// </summary>
        /// <returns> numero total de colaboradores </returns>
        public static int TotalColaboradores()
        {
            return lstColaboradores.Count;
        }
        #endregion

        #region Verification
        /// <summary>
        /// Verifica se já existe o colaborador
        /// </summary>
        /// <param name="codColaborador">Codigo da auditoria</param>
        /// <returns> Devolve true/false consoante exista a auditoria</returns>
        public static bool ProcuraColaborador(int codColaborador)
        {
            int i = 0;
            for (; i < TotalColaboradores(); i++)
            {
                if (lstColaboradores[i].Codigo == codColaborador && lstColaboradores[i].Estado == Colaborador.State.ATIVO) { return true; }

            }
            return false;
        }
        /// <summary>
        /// Adiciona um Colaborador a lista
        /// </summary>
        /// <param name="col">colaborador a ser adicionado</param>
        /// <returns> Devolve true/false consoante adicione ou não o colaborador</returns>
        public static bool InsereColaboradores(Colaborador col)
        {
            try
            {   
                lstColaboradores.Add(col);
                return true;
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
        /// Apresenta todos os colaboradores
        /// </summary>
        public static void ApresentarColaboradores()
        {
            int i = 0;
            Console.WriteLine("=======================================Colaboradores==========================================");
            Console.WriteLine(" {0,-7}|{1,-15}|{2,-14}|{3,-15}", "Código", "Nome", "Estado","Nº Auditorias");
            for (; i < TotalColaboradores(); i++)
            {
                Console.WriteLine(" {0}", lstColaboradores[i].ToString());
            }
        }
        /// <summary>
        /// Apresenta todas as auditorias realizadas por um colaboradore
        /// </summary>
        public static void ApresentarAuditoriasColaborador()
        {
            int i = 0;
            int j = 0;
            for (; i < TotalColaboradores(); i++)
            {
                j = 0;
                Console.WriteLine("");
                Console.WriteLine(" Colaborador : {0} {1}\n {2,-15}|{3,-20}|{4,-10}",lstColaboradores[i].Codigo.ToString(),lstColaboradores[i].Nome,"Cod. Auditoria","Data","Duração");
                if (lstColaboradores[i].CodAudColaborador.Count == 0) { Console.WriteLine("\tNão realizou auditorias"); }
                else
                {
                    for (; j < lstColaboradores[i].CodAudColaborador.Count; j++)
                    {
                        Auditoria aux = Auditorias.EncontraAuditoria(lstColaboradores[i].CodAudColaborador[j]);
                        Console.WriteLine(" {0,-15}|{1,-20}|{2,-10}", aux.Codigo.ToString(), aux.Data.ToShortDateString(), aux.Duracao.ToString());
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
        public static bool Save(string fileColaboradores)
        {
            try
            {
                Stream s = File.Open(fileColaboradores, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, lstColaboradores);
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
        public static bool Load(string fileColaboradores)
        {
            try
            {
                Stream s = File.Open(fileColaboradores, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                lstColaboradores = (List<Colaborador>)b.Deserialize(s);
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
        ~Colaboradores() { }
        #endregion

        #region Enums
        #endregion
    }
}
