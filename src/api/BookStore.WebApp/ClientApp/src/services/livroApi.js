import { Api } from "./api";

export const buscar = async () => {
    return await Api.getData('GET', 'api/livro');
}

export const buscarPorId = async (id) => {
    return await Api.getData('GET', 'api/livro', { id });
}

export const novo = async (obj) => {
    return await Api.getData('POST', 'api/livro', obj);
}

export const atualizar = async (obj) => {
    return await Api.getData('PUT', 'api/livro', obj);
}