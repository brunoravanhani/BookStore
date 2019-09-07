import { Api } from "./api";

export const buscar = async () => {
    return await Api.getData('GET', 'api/editora');
}

export const buscarPorId = async (id) => {
    return await Api.getData('GET', 'api/editora', { id });
}

export const novo = async (obj) => {
    return await Api.getData('POST', 'api/editora', obj);
}

export const atualizar = async (obj) => {
    return await Api.getData('PUT', 'api/editora', obj);
}

export const excluir = async (id) => {
    return await Api.getData('DELETE', `api/editora/${id}`, null);
}