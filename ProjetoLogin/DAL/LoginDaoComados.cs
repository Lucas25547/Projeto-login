﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.DAL
{
    class LoginDaoComados
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        conexao con = new conexao();
        SqlDataReader dr;
        public bool verificarLogin(String login, String senha)
        {
            //
            cmd.CommandText = "select * from logins where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    tem = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }
            return tem;
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            tem = false;
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "insert into logins values (@e,@s);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", senha);

                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = "Cadastrado com sucesso";
                    tem = true;
                }
                catch (SqlException)
                {
                    this.mensagem = "Erro com Banco de Dados";
                }
            }else
            {
                this.mensagem = "Senhas não correspondem";
            }
            return mensagem;
        }
    }
}
