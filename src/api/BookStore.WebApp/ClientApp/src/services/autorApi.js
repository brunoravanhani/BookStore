import { Api } from "./api";

export const buscar = async () => {
    return await Api.getData('GET', 'api/autor');
}

export const buscarPorId = async (id) => {
    return await Api.getData('GET', 'api/autor', { id });
}

export const novo = async (obj) => {
    return await Api.getData('POST', 'api/autor', obj);
}

export const atualizar = async (obj) => {
    return await Api.getData('PUT', 'api/autor', obj);
}

export const excluir = async (id) => {
    return await Api.getData('DELETE', `api/autor/${id}`, null);
}