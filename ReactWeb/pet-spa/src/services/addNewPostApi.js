import axios from 'axios'

const baseUrl = 'https://localhost:7074/api/';


const AddNewPost = (formData) =>
    axios({
        method: "post",
        url: `${baseUrl}userPost/AddNewPost`,
        data: formData,
    })

export const addNewPostApi = {
    AddNewPost
    
};