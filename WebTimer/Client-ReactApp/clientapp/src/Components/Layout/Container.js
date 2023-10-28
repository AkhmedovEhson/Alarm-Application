import React, { Children, Component } from "react";

class Container extends React.Component{

    constructor(props){
        super(props);
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