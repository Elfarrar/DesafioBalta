using Model;

namespace TemplateTest.Model
{
    public class TemplateTest
    {
        Template.Model.Template _Template;

        public TemplateTest()
        {
            _Template = new Template.Model.Template();
        }

        [Fact]
        [Trait("Category", "Template")]
        public void Ao_criar_um_novo_Template_ele_deve_gerar_um_Id_no_formato_GUID()
        {
            Assert.IsType<Guid>(_Template.Id);
        }

        [Fact]
        [Trait("Category", "Template")]
        public void Ao_criar_um_novo_Template_ele_deve_ter_uma_lista_de_audit_vazia()
        {
            Assert.IsType<List<Audit>>(_Template.Audit);
            Assert.NotNull(_Template.Audit);
        }

        [Fact]
        [Trait("Category", "Template")]
        public void Ao_criar_um_novo_Template_ele_deve_ter_IsDeleted_igual_a_False()
        {
            Assert.False(_Template.IsDeleted);
        }

    }
}
