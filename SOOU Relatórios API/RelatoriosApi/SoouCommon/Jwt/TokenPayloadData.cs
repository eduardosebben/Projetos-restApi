using System;
using SoouCommon.Enum;

namespace SoouCommon.Jwt
{

    /// <summary>
    /// Dados de identificação do usuário, organização e aplicação que estarão criptografados no payload da JWT.
    /// </summary>
    public class TokenPayloadData
    {
        /// <summary>
        /// GUID identificador da organização selecionada.
        /// </summary>
        public string OrgGuid { get; set; }
        /// <summary>
        /// GUID identificador do usuário logado.
        /// </summary>
        public string UserGuid { get; set; }
        /// <summary>
        /// Identificador da aplicação originária da comunicação.
        /// </summary>
        public TipoAplicacao OriginApp { get; set; }
        /// <summary>
        /// Identificador do ambiente da aplicação originária da comunicação.
        /// </summary>
        public TipoAmbiente OriginEnv { get; set; }
        /// <summary>
        /// Identifica se a organização deve ser validada no Account
        /// </summary>
        public bool TipValidarRelacaoOrganizacao { get; set; } = false;
    }
}
