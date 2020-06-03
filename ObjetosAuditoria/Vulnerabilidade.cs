using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepcoes;
/*  -------------------------------------------------
 * <copyright file="Vulnerabilidade.cs" company="IPCA"/>
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
 *   Vulnerabilidade
 * </desc>
 * -------------------------------------------------
*/
namespace ObjetosAuditoria
{
    [Serializable]
    /// <summary>
    /// classe vulnerabilidade
    /// </summary>
    public class Vulnerabilidade
    {
        #region Member Variables
        private int codigo;
        private string descricao;
        private Level nivel;
        private State estado;
        private List<int> codEqVuln;                    // Equipamentos presentes numa vulnerabilidade
        private List<int> codAuditoria;                 // Conjunto de auditorias em que a vulnerabilidade esta presente
        private static int countCodigo;                 // Contador para o codigo da vulnerabilidade
        #endregion

        #region Constructors
        static Vulnerabilidade()
        {
            countCodigo = 0;
        }
        /// <summary>
        /// Construtor por defeito
        /// </summary>
        public Vulnerabilidade()
        {
            this.descricao = "";
            this.nivel = Level.BAIXO;
            this.estado = State.NAO;
            this.codigo = CodigoVulnerabilidade();
            this.codEqVuln = new List<int>();
            this.codAuditoria = new List<int>();
        }
        /// <summary>
        /// Construtor com valores
        /// </summary>
        /// <param name="d">descrição da vulnerabilidade</param>
        /// <param name="n">Nivel da vulnerabilidade</param>
        public Vulnerabilidade(string d, Level n)
        {
            this.descricao = d;
            this.nivel = n;
            this.estado = State.NAO;
            this.codigo = CodigoVulnerabilidade();
            this.codEqVuln = new List<int>();
            this.codAuditoria = new List<int>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Para permitir verificar o codigo
        /// </summary>
        public int Codigo
        {
            get { return codigo; }
        }
        /// <summary>
        /// Para permitir alterar o valor do estado
        /// </summary>
        public State Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        /// <summary>
        /// Para permitir alterar o valor do nivel
        /// </summary>
        public Level Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        /// <summary>
        /// Para permitir alterar o valor da descrição
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        /// <summary>
        /// Para permitir alterar o valor do numero de auditorias na vulnerabilidade
        /// </summary>
        public List<int> CodAuditoria
        {
            get { return codAuditoria; }
            set { codAuditoria = value; }
        }
        /// <summary>
        /// Para permitir alterar o valor do numero de equipamentos na vulnerabilidade
        /// </summary>
        public List<int> CodEqVuln
        {
            get { return codEqVuln; }
            set { codEqVuln = value; }
        }

        #endregion

        #region Functions
        /// <summary>
        /// Determina o código da vulnerabilidade
        /// </summary>
        /// <returns> Devolve o código vulnerabilidade</returns>
        public static int CodigoVulnerabilidade()
        {
            countCodigo++;
            return countCodigo;
        }
        /// <summary>
        /// Para inserir equipamentos numa vulnerabilidade
        /// </summary>
        /// <param name="equip">Conjunto de todos equipamentos</param>
        /// <returns> Devolve true/false consoante conseguiu adicionar o equipamento a vulnerabilidade </returns>
        public bool InserirEquipVulnerabilidade(Equipamento equip)
        {
            try
            {
                this.codEqVuln.Add(equip.Codigo);
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
        /// Para inserir auditoria numa vulnerabilidade 
        /// </summary>
        /// <param name="a">Auditoria pretendida</param>
        /// <returns> Devolve true/false consoante conseguiu adicionar a auditoria a vulnerabilidade </returns>
        public bool InserirAudVulnerabilidade(Auditoria a)
        {
            try
            {
                this.codAuditoria.Add(a.Codigo);
                return true; 
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
        /// Para alterar o estado de uma vulnerabilidade 
        /// </summary>
        /// <returns> Devolve true/false consoante conseguiu alterar o estado da vulnerabilidade </returns>
        public bool ResolveVulnerabilidade()
        {
            try
            {
                this.estado = State.SIM;
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
        /// Altera o ToString da Vulnerabilidade para o formato pretendido
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0,-7}|{1,-30}|{2,-10}|{3,-20}|{4,-15}|{5,-10}", codigo.ToString(), descricao, nivel.ToString(),codEqVuln.Count.ToString(), 
                                                                    codAuditoria.Count.ToString(), estado.ToString());
        }
        #endregion

        #region Enums
        /// <summary>
        /// Colocar valores predefinidos no atributo nivel
        /// </summary>
        public enum Level
        {
            BAIXO, 
            MODERADO,
            ELEVADO
        }
        /// <summary>
        /// Colocar valores predefinidos no atributo estado
        /// sim -> se estiver resolvida
        /// nao -> se não estiver resolvida
        /// </summary>
        public enum State
        {
            SIM,
            NAO
        }
        #endregion
    }
}
