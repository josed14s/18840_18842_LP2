using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Excepcoes;
/*  -------------------------------------------------
* <copyright file="Auditoria.cs" company="IPCA"/>
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
*   Auditoria
* </desc>
* -------------------------------------------------
*/

namespace ObjetosAuditoria
{
    [Serializable]
    /// <summary>
    /// classe Auditoria
    /// </summary>
    public class Auditoria
    {
        #region Member Variables
        private int codigo;
        private DateTime data;
        private int duracao;                            // em minutos
        public int codColaborador;                      // Codigo do colaborador que realizou a auditoria
        private List<int> codVulns;                     // Conjunto de codigos de vulnerabilidades
        private static int countCodigo;                 // Contador para o codigo da Auditoria
        #endregion

        #region Constructors
        static Auditoria()
        {
            countCodigo = 0;
        }
        /// <summary>
        /// Construtor por defeito
        /// </summary>
        public Auditoria()
        {
            this.duracao = 0;
            this.codigo = CodigoAuditoria();
            this.codColaborador = -1;
            this.data = DateTime.Now;
            this.codVulns = new List<int>();
        }
        /// <summary>
        /// Construtor com valores
        /// </summary>
        /// <param name="d">duração da auditoria</param>
        /// <param name="col">colaborador</param>
        /// <param name="data">data da auditoria</param>
        public Auditoria(int d, Colaborador col, string data)
        {
            this.duracao = d;
            this.codigo = CodigoAuditoria();
            this.codColaborador = col.Codigo;
            this.data = DateTime.Parse(data);
            this.codVulns = new List<int>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Para permitir alterar e verificar o valor do codigo do Colaborador
        /// </summary>
        public int CodColaborador
        {
            get { return codColaborador; }
            set { codColaborador = value; }
        }
        /// <summary>
        /// Para permitir alterar e verificar a duração
        /// </summary>
        public int Duracao
        {
            get { return duracao; }
            set { duracao = value; }
        }
        /// <summary>
        /// Para permitir verificar o codigo
        /// </summary>
        public int Codigo
        {
            get { return codigo; }
        }
        /// <summary>
        /// Para permitir alterar e verificar a data da auditoria
        /// </summary>
        public DateTime Data
        {
            get { return data; }
            set {DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true){ data = value; }
            }
        }
        /// <summary>
        /// Para permitir verificar o numero e codigos das vulnerabilidades
        /// </summary>
        public List<int> CodVulns
        {
            get { return codVulns; }
            set { codVulns = value; }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Determina o código da auditoria
        /// </summary>
        /// <returns> Devolve o código auditoria</returns>
        public static int CodigoAuditoria()
        {
            countCodigo++;
            return countCodigo;
        }
        /// <summary>
        /// Calcula o numero total de vulnerabilidades
        /// </summary>
        /// <returns> numero total de vulnerabilidades </returns>
        public int TotalVulnAuditorias()
        {
            return this.codVulns.Count;
        }
        /// <summary>
        /// Altera o ToString da Auditoria para o formato pretendido
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0,-7}|{1,-15}|{2,-10}|{3,-17}|{4,-10}", codigo.ToString(),data.ToShortDateString(),duracao.ToString(),codColaborador.ToString(),codVulns.Count.ToString());
        }
        /// <summary>
        /// Para inserir vulnerabilidades nas auditorias
        /// </summary>
        /// <param name="vuln">Vulnerabilidade a inserir</param>
        /// <returns> Devolve true/false consoante conseguiu adicionar a vulnerabilidade a auditoria </returns>
        public bool InserirVulnAuditoria(Vulnerabilidade vuln)
        {
            try
            {
                this.codVulns.Add(vuln.Codigo);
                return true;
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
        #endregion

        #region Enums
        #endregion
    }
}
