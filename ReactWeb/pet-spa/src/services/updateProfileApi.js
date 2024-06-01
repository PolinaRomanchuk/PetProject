import axios from 'axios'

const baseUrl = 'https://localhost:7074/api/';

const UpdateProfileApi = (petName, petInfo, userId) =>
    axios
        .post(`${baseUrl}user/UpdateProfile?petName=${petName}&petInfo=${petInfo}&id=${userId}`);

const UpdateAvatarApi = (formData) =>
    axios({
        method: "post",
        url: `${baseUrl}user/UpdateAvatar`,
        data: formData,
    })

export const updateProfileApi = {
    UpdateProfileApi,
    UpdateAvatarApi
};