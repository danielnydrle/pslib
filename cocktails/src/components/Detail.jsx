import {useState, useEffect} from "react";
import {Alert, Spinner, Card, CardBody, CardTitle, CardSubtitle, CardImg, CardText} from "reactstrap";
import axios from "axios";
import {API} from "../configuration/api";
import { useParams } from "react-router-dom";

const Detail = props => {
    const {id} = useParams();
    const [data, setData] = useState(null);
    const [error, setError] = useState(false);
    const [isLoading, setIsLoading] = useState(false);
    useEffect(() => {
        setIsLoading(true);
        axios.get(API + "lookup.php?i=" + id )
        .then(response => {
            if (Array.isArray(response.data.drinks)) {
                setData(response.data.drinks[0]);
                setError(false);
            }
            else
            {
                setData(null);
                setError(false);
            }    
        })
        .catch(error => {
            setError(true);
            setData(null);
        })
        .then(()=>{
            setIsLoading(false);
        })
    },[id]);
    const ingredients = [];  
    if (error)
    {
        if (error.response) {
            return <Alert color="danger">There was an error ({error.response.status}).</Alert>
        }
        else
        {
            return <Alert color="danger">There was an unknown error.</Alert>
        }  
        
    }
    else if (isLoading)
    {
        return <Spinner color="success" />
    }
    else if (data)
    {
        for (let i=1; i <= 15; i++)
        {
            if (data["strIngredient" + i])
            {
                ingredients.push(
                    <tr key={i}>
                        <td>{data["strIngredient" + i]}</td>
                        <td>{data["strMeasure" + i]}</td>
                    </tr>
                );
            }
        }
        return (
            <Card>
                <CardImg top width="100%" src={data.strDrinkThumb} alt={data.strDrink} />
                <CardBody>
                    <CardTitle tag="h2">{data.strDrink}</CardTitle>
                    <CardText>{data.strCategory}</CardText>
                    <CardText>Glass: {data.strGlass}</CardText>
                    <CardSubtitle tag="h3" className="mb-2 text-muted">Ingredients</CardSubtitle>
                    <table className="table">
                    {ingredients}
                    </table>
                    <CardSubtitle tag="h3" className="mb-2 text-muted">Instructions</CardSubtitle>
                    <CardText>{data.strInstructions}</CardText>
                </CardBody>
            </Card>
        );
    }
    else if (data === null && error === false)
    {
        return <Alert color="info">There is no such drink</Alert>
    }
    else
    {
        return <Spinner color="primary" />;
    }
}

export default Detail;