import '../../css/profile.css'

function Post({ model }) {

    return (
        <>
            <div class="post-item">
                <img src={model} />
            </div>
        </>
    );
};

export default Post;
