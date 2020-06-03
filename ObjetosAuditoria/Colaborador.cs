using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Excepcoes;
/*  -------------------------------------------------
* <copyright file="Colaborador.cs" company="IPCA"/>
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
*   Colaborador
* </desc>
* -------------------------------------------------
*/

namespace ObjetosAuditoria
{
    [Serializable]
    /// <summary>
    /// classe Colaborador
    /// Responsável por tratar de Colaboradores
    /// </summary>
    public class Colaborador
    {
        #region Member Variables
        private string nome;
        private int codigo;
        private State estado;
        private List<int> codAudColaborador;        //Conjunto de auditorias realizadas pelo Colaborador
        private static int countCodigo;             //Contador para o codigo dos Colaboradores
        #endregion

        #region Constructors
        static Colaborador()
        {
            countCodigo = 0;
        }
        /// <summary>
        /// Construtor por defeito
        /// </summary>
        /// <param name="cod">codigo do colaborador</param>
        public Colaborador()
        {
            this.nome = "";
            this.codigo = CodigoColaborador();
            this.estado = State.ATIVO;
            this.codAudColaborador = new List<int>();
        }
        /// <summary>
        /// Construtor com valores
        /// </summary>
        /// <param name="n">Nom do colaborador</param>
        /// <param name="cod">codigo do colaborador</param>
        public Colaborador(string n)
        {
            this.nome = n;
            this.codigo = CodigoColaborador(); 
            this.estado = State.ATIVO;
            this.codAudColaborador = new List<int>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Para permitir alterar o valor do estado
        /// </summary>
        public State Estado 
        {
            get { return estado; }
            set { estado = value; }
        }
        /// <summary>
        /// Para permitir verificar o codigo
        /// </summary>
        public int Codigo
        {
            get { return codigo; }
        }
        /// <summary>
        /// Para permitir alterar o valor do nome
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        /// <summary>
        /// Para permitir alterar o valor da lista das auditorias
        /// </summary>
        public List<int> CodAudColaborador
        {
            get { return codAudColaborador; }
            set { codAudColaborador = value; }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Determina o código do Colaborador
        /// </summary>
        /// <returns> Devolve o código do colaborador</returns>
        public static int CodigoColaborador()
        {
            countCodigo++;
            return countCodigo;
        }
        /// <summary>
        /// Para inserir auditorias nos colaboradores
        /// </summary>
        /// <param name="aud">Conjunto de todas as auditorias</param>
        /// <param name="codColaborador">Codigo do colaborador</param>
        /// <param name="cols">Colaborador onde pretende introduzir auditoria</param>
        /// <returns> Devolve a variavel cols com a respetiva auditoria adicionada </returns>
        public bool InserirAudColaborador(Auditoria aud)
        {
            try
            {
                this.codAudColaborador.Add(aud.Codigo);
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
        /// <summary>
        /// Para alterar o estado de um Colaborador 
        /// </summary>
        /// <returns> Devolve true/false consoante conseguiu alterar o estado do Colaborador </returns>
        public bool RemoverColaborador()
        {
            try
            {
                this.estado = State.INATIVO;
                return true;
            }
            catch (ColaboradorInexistenteException e)
            {
                throw new ColaboradorInexistenteException("ERRO! " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Altera o ToString do Colaborador para o formato pretendido
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0,-7}|{1,-15}|{2,-14}|{3,-15}", codigo.ToString(),nome, estado.ToString(),codAudColaborador.Count.ToString());
        }
        #endregion

        #region Enums
        /// <summary>
        /// Colocar valores predefinidos no atributo estado
        /// </summary>
        public enum State
        {
            ATIVO,
            INATIVO
        }
        #endregion
    }
}
