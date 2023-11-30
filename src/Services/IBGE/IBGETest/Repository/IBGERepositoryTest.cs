using IBGE.Data;
using IBGE.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Enums;

namespace IBGETest.Repository
{
    public class IBGERepositoryTest
    {
        IBGE.Model.IBGE _IBGE;

        public IBGERepositoryTest()
        {
            _IBGE = new IBGE.Model.IBGE();
        }

        [Fact]
        [Trait("Category", "IBGERepository")]
        public async Task Ao_salvar_um_novo_IBGE_no_banco_ele_deve_ter_um_elemento_audit_do_tipo_Created_e_IsDeleted_igual_false()
        {
            var options = new DbContextOptionsBuilder<IBGEContext>()
                .UseInMemoryDatabase(databaseName: "IBGEs")
                .Options;

            var context = new IBGEContext(options);

            var _repository = new IBGERepository(context);

            var result = await _repository.Create(_IBGE);

            Assert.Equal(result.Audit.FirstOrDefault().Type, AuditType.Create);
            Assert.False(result.IsDeleted);
        }

        [Fact]
        [Trait("Category", "IBGERepository")]
        public async Task Ao_atualizar_um_IBGE_no_banco_ele_deve_ter_um_elemento_audit_do_tipo_update_e_IsDeleted_igual_false()
        {
            var options = new DbContextOptionsBuilder<IBGEContext>()
                .UseInMemoryDatabase(databaseName: "IBGEs")
                .Options;

            var context = new IBGEContext(options);

            context.IBGE.Add(new IBGE.Model.IBGE() { });

            var _repository = new IBGERepository(context);

            await _repository.Create(_IBGE);
            var result = await _repository.Update(_IBGE);

            Assert.True(result.Audit.Any(x => x.Type == AuditType.Update));
            Assert.False(result.IsDeleted);
        }

        [Fact]
        [Trait("Category", "IBGERepository")]
        public async Task Ao_deletar_um_IBGE_no_banco_ele_deve_ter_um_elemento_audit_do_tipo_delete_e_IsDeleted_igual_true()
        {
            var options = new DbContextOptionsBuilder<IBGEContext>()
                .UseInMemoryDatabase(databaseName: "IBGEs")
                .Options;

            var context = new IBGEContext(options);

            context.IBGE.Add(new IBGE.Model.IBGE() { });

            var _repository = new IBGERepository(context);

            await _repository.Create(_IBGE);
            var result = await _repository.Delete(_IBGE);

            Assert.True(result.Audit.Any(x => x.Type == AuditType.Delete));
            Assert.True(result.IsDeleted);
        }
    }
}
