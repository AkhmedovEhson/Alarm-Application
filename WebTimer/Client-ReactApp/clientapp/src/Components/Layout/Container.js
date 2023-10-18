import React, { Children, Component } from "react";

class Container extends React.Component{

    constructor(props){
        super(props)
        for(let i in Children.toArray()){
            console.log(i);
        }
    }

    render(){
        return(
            <div className='container-app'> 
                {this.props.children}
            </div>
        )
    }
}
export default Container;