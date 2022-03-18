import {React, useState} from "react";
import Search from "./Search";
import NothingFound from "./NothingFound";
import DrinksList from "./DrinksList";
const Title = props => {
    const [searchResults, setSearchResults] = useState([]);
    return (
        <>
        <Search setSearchResults={setSearchResults} />
        {searchResults.length === 0 ? <NothingFound /> : <DrinksList items={searchResults} />}
        </>
    );
}

export default Title;