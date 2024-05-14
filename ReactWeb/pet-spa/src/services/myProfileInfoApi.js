import axios from 'axios'

const baseUrl = 'https://localhost:7074/api/';

const GetUserProfile = (userId) =>
    axios
        .get(`${baseUrl}user/OpenUserProfile?id=${userId}`);


export const profileApi = {
    GetUserProfile
};
