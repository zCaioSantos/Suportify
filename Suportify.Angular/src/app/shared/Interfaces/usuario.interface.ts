export interface IUsuario {
  Id: string;
  Email: string;
  Senha: string;
  Foto?: string;
  Token?: string;
  ExpiracaoToken?: Date;
  RefreshToken?: string;
  CodigoRecuperacaoSenha?: string;
  DataExpiracaoCodigo?: Date;
  Ativo: boolean;
}

export type UsuarioDto = Partial<IUsuario>;


const test: IUsuario = {
  Id:  "est"
}
