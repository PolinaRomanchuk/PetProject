import axios from 'axios'

const baseUrl = 'https://localhost:7074/api/';


const GetPost = (id) =>
    axios
        .get(`${baseUrl}userPost/OpenPost?id=${id}`);

export const openPostApi = {
    GetPost
};