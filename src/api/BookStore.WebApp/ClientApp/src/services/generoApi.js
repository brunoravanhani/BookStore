import { Api } from "./api";

export const buscar = async () => {
    return await Api.getData('GET', 'api/genero');
}

export const buscarPorId = async (id) => {
    return await Api.getData('GET', 'api/genero', { id });
}

export const novo = async (obj) => {
    return await Api.getData('POST', 'api/genero', obj);
}

export const atualizar = async (obj) => {
    return await Api.getData('PUT', 'api/genero', obj);
}

export const excluir = async (id) => {
    return await Api.getData('DELETE', `api/genero/${id}`, null);
}