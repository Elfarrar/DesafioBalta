using Microsoft.EntityFrameworkCore;
using Model.Enums;
using Template.Data;
using Template.Repository;

namespace TemplateTest.Repository
{
    public class TemplateRepositoryTest
    {
        Template.Model.Template _Template; 

        public TemplateRepositoryTest()
        {
            _Template = new Template.Model.Template();
        }

        [Fact]
        [Trait("Category", "TemplateRepository")]
        public async Task Ao_salvar_um_novo_Template_no_banco_ele_deve_ter_um_elemento_audit_do_tipo_Created_e_IsDeleted_igual_false()
        {
            var options = new DbContextOptionsBuilder<TemplateContext>()
                .UseInMemoryDatabase(databaseName: "Templates")
                .Options;

            var context = new TemplateContext(options);

            var _repository = new TemplateRepository(context);

            var result = await _repository.Create(_Template);

            Assert.Equal(result.Audit.FirstOrDefault().Type, AuditType.Create);
            Assert.False(result.IsDeleted);
        }

        [Fact]
        [Trait("Category", "TemplateRepository")]
        public async Task Ao_atualizar_um_Template_no_banco_ele_deve_ter_um_elemento_audit_do_tipo_update_e_IsDeleted_igual_false()
        {
            var options = new DbContextOptionsBuilder<TemplateContext>()
                .UseInMemoryDatabase(databaseName: "Templates")
                .Options;

            var context = new TemplateContext(options);

            context.Template.Add(new Template.Model.Template() { });

            var _repository = new TemplateRepository(context);

            await _repository.Create(_Template);
            var result = await _repository.Update(_Template);

            Assert.True(result.Audit.Any(x=>x.Type == AuditType.Update));
            Assert.False(result.IsDeleted);
        }

        [Fact]
        [Trait("Category", "TemplateRepository")]
        public async Task Ao_deletar_um_Template_no_banco_ele_deve_ter_um_elemento_audit_do_tipo_delete_e_IsDeleted_igual_true()
        {
            var options = new DbContextOptionsBuilder<TemplateContext>()
                .UseInMemoryDatabase(databaseName: "Templates")
                .Options;

            var context = new TemplateContext(options);

            context.Template.Add(new Template.Model.Template() { });

            var _repository = new TemplateRepository(context);

            await _repository.Create(_Template);
            var result = await _repository.Delete(_Template);

            Assert.True(result.Audit.Any(x => x.Type == AuditType.Delete));
            Assert.True(result.IsDeleted);
        }
    }
}
