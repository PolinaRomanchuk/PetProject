import axios from 'axios'

const baseUrl = 'https://localhost:7074/api/';

const CreateUserByApi = (login, password, email) =>
    axios
        .post(`${baseUrl}user/CreateNewUser?loginName=${login}&password=${password}&email=${email}`);

export default CreateUserByApi;
