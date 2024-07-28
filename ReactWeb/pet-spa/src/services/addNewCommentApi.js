import axios from 'axios'

const baseUrl = 'https://localhost:7074/api/';

/*const AddNewComment = (commentText, userId, model) =>
    axios
        .post(`${baseUrl}commentPost/CreateNewComment?commentAuthor=${userId}&commentText=${commentText}&currentPost=${model}`, {headers: {'Content-Type': 'application/json'}});
*/

        const AddNewComment = (formData) =>
            axios({
                method: "post",
                url: `${baseUrl}commentPost/CreateNewComment`,
                data: formData,
            })

export const addNewCommentApi = {
    AddNewComment
};