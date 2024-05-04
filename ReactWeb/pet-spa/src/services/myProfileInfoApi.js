import axios from 'axios'

const baseUrl = 'https://localhost:7074/api/';

const GetUserId = (login, password) =>
    axios
        .get(`${baseUrl}login/GetUserId?login=${login}&password=${password}`);

const GetUser = (id) =>
    axios
        .get(`${baseUrl}login/GetUser?id=${id}`);


export const loginApi = {
    GetUserId,
    GetUser
};
