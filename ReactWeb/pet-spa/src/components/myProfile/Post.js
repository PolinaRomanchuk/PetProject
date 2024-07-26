import '../myProfile/profile.css'
import Modal from '../modal/modal';
import { useState, useEffect } from 'react';
import OpenPost from './openPost';

function Post({ model, userPhoto, fullmodel }) {
    const [active, setActive] = useState(false);


    return (
        <>
            <div className="post-item" >
               
                     <img src={model.imageUrl} onClick={() => setActive(true)} />
                    

            </div>
            <Modal active={active} setActive={setActive}>
                <OpenPost active={active} setActive={setActive} model={model} userPhoto={userPhoto} fullmodel={fullmodel} />
            </Modal>
        </>
    );
};

export default Post;
