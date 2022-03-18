import {InputGroup, InputGroupAddon, Input, Button} from "reactstrap";
import {React, useState} from "react";
import axios from "axios";
import {API} from "../configuration/api";

const Search = (props) => {
    const [searchText, setSearchText] = useState("");
    const processSearch = (text) => {
        console.log(text);
        axios.get(API + "search.php?s=" + text)
        .then(response => {
            if (response.data.drinks) {
                props.setSearchResults(response.data.drinks);
            }
        })
    }
    return (
        <>
        <InputGroup>
            <Input 
                name="search" 
                id="search" 
                placeholder="Martini, Margarita, Bloody Mary, ..."
                value={searchText}
                onChange={e => {
                    setSearchText(e.target.value)
                    if (searchText.length >= 2) processSearch(searchText);
                }}
            />
            <InputGroupAddon addonType="prepend">
                <Button color="primary" onClick={e=>{
                    if (searchText.length >= 2) processSearch(searchText);
                }} disabled={searchText.length === 0}>Search</Button>
            </InputGroupAddon>
        </InputGroup>        
        </>
    );
}

export default Search;