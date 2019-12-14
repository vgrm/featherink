import React from "react";
import { Row, Col, ListGroup, ListGroupItem, Image } from "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";


import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
        padding: theme.spacing(2)
    },
    card: {
        maxWidth: 345,
    },
    media: {
        height: 140,
    },
}));

function NewDesignerCard({ designers }) {
    NewDesignerCard.propTypes = {
        designers: PropTypes.array
    };

    const classes = useStyles();

    return (
        <div>
            <Grid
                container
                spacing={2}
                direction="row"
                justify="flex-start"
                alignItems="flex-start"
            >
                {designers.map(designer => (
                    <Grid item xs={12} sm={6} md={3} key={designer.id}>
                <Card className={classes.card}>
                    <CardActionArea>
                        <CardMedia
                                    className={classes.media}
                                    image={designer.image}
                                    title={designer.name + "_Image"}
                        />
                        <CardContent>
                            <Typography gutterBottom variant="h5" component="h2">
                                        {designer.name}
          </Typography>
                                    <Typography variant="body2" color="textSecondary" component="p">
                                        {designer.description}
          </Typography>
                        </CardContent>
                    </CardActionArea>
                    <CardActions>
                        <Button size="small" color="primary">
                            Share
        </Button>
                        <Button size="small" color="primary">
                            Learn More
        </Button>
                    </CardActions>
                        </Card>
                    </Grid>
            ))};
</Grid>    
        </div>
    );

    /*
    return (
        <div>
            {designers.map(designer => (
                <Card className={classes.card}>
                    <CardActionArea>
                        <CardMedia
                            className={classes.media}
                            image="/static/images/cards/contemplative-reptile.jpg"
                            title="Contemplative Reptile"
                        />
                        <CardContent>
                            <Typography gutterBottom variant="h5" component="h2">
                                Lizard
          </Typography>
                            <Typography variant="body2" color="textSecondary" component="p">
                                Lizards are a widespread group of squamate reptiles, with over 6,000 species, ranging
                                across all continents except Antarctica
          </Typography>
                        </CardContent>
                    </CardActionArea>
                    <CardActions>
                        <Button size="small" color="primary">
                            Share
        </Button>
                        <Button size="small" color="primary">
                            Learn More
        </Button>
                    </CardActions>
                </Card>
            ))};
        </div>
    );

    */
    /*
    return (
        <div>
            {designers.map(designer => (
                <Card key={designer.id}>
                    <Image src={designer.image} />
                    <Link to={`/designer/${designer.id}`}> {designer.name} </Link>
                    {designer.description}
                </Card>
            ))};
        </div>
    );
    */

    /*
    return (
        <Card>
            <Card.Header>
                New designers
            </Card.Header>
            <ListGroup className="list-group-flush">
                {designers.map(designer => (
                    <ListGroupItem key={designer.id}>
                        <div>
                            <Image src={designer.image} />
                            <Link to={`/designer/${designer.id}`}> {designer.name} </Link>
                        </div>
                        <div>
                            {designer.description}
                        </div>
                        
                    </ListGroupItem>
                ))}
            </ListGroup>
        </Card>
    ); 
    */
}

class Designer extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            designers: []
        };

        fetch('api/designer')
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        designers: result
                    });
                });
    }


    render() {
        return (
            <div>
                <h1>Hello, world! FeatherInk L2</h1>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <NewDesignerCard {...this.state} />
                            </Col>
                        </Row>
                    </Col>

                </Row>
            </div>
        );
    }
}

export default Designer;