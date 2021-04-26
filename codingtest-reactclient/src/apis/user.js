const baseUrl=process.env.REACT_APP_API_URL;
const  loginUser = async (formData)=>{
     console.log(formData,baseUrl)
    let resp =await fetch(baseUrl+"/account/login",{
            method:"POST",
            headers:{
                "Content-Type":'application/json; charset=utf-8',
            },
            mode:'cors',
            body: JSON.stringify({
                "email":formData.email,
                "password":formData.password,
                
            })
        }).then(res=> {
            console.log(res, formData)
            return res.json()
        }).catch( (e)=>{
            return {
                    "statusCode":"500"
                };
        })

    return resp;
}

export default loginUser;