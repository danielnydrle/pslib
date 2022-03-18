import { ListGroup, ListGroupItem } from 'reactstrap';
import { Link } from "react-router-dom";

const DrinksList = ({items}) => {
    if (items.length > 0)
    {
        return (
            <ListGroup>
            {items.map((item, index) => 
            (
                <ListGroupItem key={index} tag={Link} to={"/detail/" + item.idDrink}>{item.strDrink}</ListGroupItem>
            ))}
            </ListGroup>
        );
    }
    else
    {
        return (
            <p>No results</p>
        );
    }
    
}

export default DrinksList;