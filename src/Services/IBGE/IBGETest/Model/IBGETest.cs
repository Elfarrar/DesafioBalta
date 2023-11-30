using Model;

namespace IBGETest.Model
{
    public class IBGETest
    {
        IBGE.Model.IBGE _IBGE;

        public IBGETest()
        {
            _IBGE = new IBGE.Model.IBGE();
        }

        [Fact]
        [Trait("Category", "IBGE")]
        public void Ao_criar_um_novo_IBGE_ele_deve_gerar_um_Id_no_formato_GUID()
        {
            Assert.IsType<Guid>(_IBGE.Id);
        }

        [Fact]
        [Trait("Category", "IBGE")]
        public void Ao_criar_um_novo_IBGE_ele_deve_ter_uma_lista_de_audit_vazia()
        {
            Assert.IsType<List<Audit>>(_IBGE.Audit);
            Assert.NotNull(_IBGE.Audit);
        }

        [Fact]
        [Trait("Category", "IBGE")]
        public void Ao_criar_um_novo_IBGE_ele_deve_ter_IsDeleted_igual_a_False()
        {
            Assert.False(_IBGE.IsDeleted);
        }

    }
}
