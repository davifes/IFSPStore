using IFSPStore.Domain.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestDomain
    {
        DateTime data = new DateTime(2024, 10, 29, 13, 0, 0);
        [TestMethod]
        public void TestCidade()
        {
            Cidade cidade = new Cidade(1, "Birigui", "SP");
            Debug.Write(JsonSerializer.Serialize(cidade));
            Assert.AreEqual(cidade.Nome, "Birigui");
            Assert.AreEqual(cidade.Estado, "SP");
        }

        [TestMethod]
        public void TestGrupo()
        {
            Grupo grupo = new Grupo(1, "Grupo 1");
            Debug.Write(JsonSerializer.Serialize(grupo));
            Assert.AreEqual(grupo.Nome, "Grupo 1");
        }

        [TestMethod]
        public void TestProduto()
        {
            Grupo grupo = new Grupo(1, "Grupo 1");
            Produto produto = new Produto(1, "Caderno", 20, 2, data, "Unidade 3", grupo);
            Debug.Write(JsonSerializer.Serialize(produto));
            Assert.AreEqual(produto.Nome, "Caderno");
            Assert.AreEqual(produto.Preco, 20);
            Assert.AreEqual(produto.Quantidade, 2);
            Assert.AreEqual(produto.DataCompra, data);
            Assert.AreEqual(produto.UnidadeVenda, "Unidade 3");
            Assert.AreEqual(produto.Grupo, grupo);
        }

        [TestMethod]
        public void TestUsuario()
        {
            Usuario usuario = new Usuario(1, "Kayky", "12345678", "Kagaya", "kaykyogaya@gmail.com", data, data, true);
            Debug.Write(JsonSerializer.Serialize(usuario));
            Assert.AreEqual(usuario.Nome, "Kayky");
            Assert.AreEqual(usuario.Senha, "12345678");
            Assert.AreEqual(usuario.Login, "Kagaya");
            Assert.AreEqual(usuario.Email, "kaykyogaya@gmail.com");
            Assert.AreEqual(usuario.DataCadastro, data);
            Assert.AreEqual(usuario.DataLogin, data);
            Assert.AreEqual(usuario.Ativo, true);
        }

        [TestMethod]
        public void TestCliente()
        {
            Cidade cidade = new Cidade(1, "Birigui", "SP");
            Cliente cliente = new Cliente(1, "Kayky", "Rua Noroeste", "Vila Roberto", "475.795.968-06", cidade);
            Debug.Write(JsonSerializer.Serialize(cliente));
            Assert.AreEqual(cliente.Nome, "Kayky");
            Assert.AreEqual(cliente.Endereco, "Rua Noroeste");
            Assert.AreEqual(cliente.Bairro, "Vila Roberto");
            Assert.AreEqual(cliente.Documento, "475.795.968-06");
            Assert.AreEqual(cliente.Cidade, cidade);
        }

        [TestMethod]
        public void TestVenda()
        {
            Grupo grupo = new Grupo(1, "Grupo 1");
            Produto produto = new Produto(1, "Caderno", 20, 2, data, "Unidade 3", grupo);
            List<VendaItem> Itens = new List<VendaItem>();
            VendaItem vendaItem = new VendaItem(1, produto, 2, 10, 20, null);
            Debug.Write(JsonSerializer.Serialize(vendaItem));
            Assert.AreEqual(vendaItem.Produto, produto);
            Assert.AreEqual(vendaItem.Quantidade, 2);
            Assert.AreEqual(vendaItem.ValorUnitario, 10);
            Assert.AreEqual(vendaItem.ValorTotal, 20);
            Venda venda = new Venda();
        }
    }
}