namespace WebApplicationImoveis.Ultilities.Middlewares
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next) => _next = next;

        public async Task VerificacaoDeExcecao(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Erro interno do servidor: {ex.Message}");
            }
        }
        public async Task ValidacaoUsuarioLogado(HttpContext context)
        {
            string usuarioLogado = context.Request.Headers["UsuarioLogado"];

            if (!string.IsNullOrEmpty(usuarioLogado))
            {
                if (usuarioLogado == "admin")
                {
                    await _next.Invoke(context); // Permite a requisição passar para o próximo middleware
                }
                else
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Acesso não autorizado.");
                }
            }
            else
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Usuário não logado.");
            }
        }



    }
}
