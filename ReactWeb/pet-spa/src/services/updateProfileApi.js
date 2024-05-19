import axios from 'axios'

const baseUrl = 'https://localhost:7074/api/';

const UpdateProfileApi = ( petName, petInfo, userId) =>
    axios
        .post(`${baseUrl}user/UpdateProfile?petName=${petName}&petInfo=${petInfo}&id=${userId}`);

export default UpdateProfileApi;