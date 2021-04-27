const baseUrl=process.env.REACT_APP_API_URL;
export const  loginUser = async (formData)=>{
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
            return res.json()
        }).catch( (e)=>{
            return {
                    status:500
                };
        })

    return resp;
}

export const  getDetails = async ()=>{
    let resp =await fetch(baseUrl+"/user/all",{
            headers:{
                "Content-Type":'application/json; charset=utf-8',
                "Authorization":"Bearer " + localStorage.getItem("token")
            },
            mode:'cors',
        }).then(res=> {
            if(res.status===401) return {status:401}
            return res.json()
        }).catch( ()=>{
            return {
                    status:500
                };
        })

    return resp;
}
