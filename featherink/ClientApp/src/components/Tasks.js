import React from "react";
import { Row, Col, ListGroup, ListGroupItem, Image } from "react-bootstrap";
import { Link as RouterLink } from "react-router-dom";
import PropTypes from "prop-types";


import { makeStyles, withStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import Link from '@material-ui/core/Link'

import colors from "../Constants/colors";


import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Slide from '@material-ui/core/Slide';

const Transition = React.forwardRef(function Transition(props, ref) {
    return <Slide direction="up" ref={ref} {...props} />;
});

const ColorButton = withStyles(theme => ({
    root: {
        color: colors.white,
        backgroundColor: colors.primaryColor,
        '&:hover': {
            backgroundColor: colors.primaryColorDark,
        },
    },
}))(Button);

const ColorButtonSecondary = withStyles(theme => ({
    root: {
        color: colors.white,
        backgroundColor: colors.secondaryColor,
        '&:hover': {
            backgroundColor: colors.secondaryColorDark,
        },
    },
}))(Button);

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
        padding: theme.spacing(2)
    },
    card: {
        maxWidth: 450,
        margin: theme.spacing(1),
        display: 'flex',
        flexDirection: 'column',
    },
    cardActionArea: {
        flexGrow: 1,
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'stretch',
    },
    media: {
        height: 140,
    },
    content: {
        flexGrow: 1,
    },
}));


function TaskCard(props) {
    TaskCard.propTypes = {
        tasks: PropTypes.array,
        handleCloseDelete: PropTypes.func
    };

    const classes = useStyles();

    const [open, setOpen] = React.useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    function handleClick() {
        setOpen(true);
    }



    return (
        <div>
            <Grid
                container
                spacing={2}
                direction="row"
                justify="flex-start"
                alignItems="flex-start"
            >
                {props.tasks.map(task => (
                    <Grid item xs={12} sm={6} md={3} key={task.id}>
                        <Card className={classes.card}>

                            <CardActionArea className={classes.cardActionArea}>
                                <CardContent className={classes.content}>
                                    <Typography gutterBottom variant="h5" component="h2">
                                        {task.name}
                                    </Typography>
                                    <Typography variant="body2" color="textSecondary" component="p">
                                        {task.description}
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                            <CardActions>
                                <ColorButton size="small" color="primary" onClick={handleClickOpen}>
                                    Accept
        </ColorButton>
                                <ColorButtonSecondary size="small" color="secondary" onClick={() => props.handleCloseDelete(task.id)}>
                                    Cancel
        </ColorButtonSecondary>
                            </CardActions>
                        </Card>

                        <Dialog
                            open={open}
                            TransitionComponent={Transition}
                            keepMounted
                            onClose={handleClose}
                            aria-labelledby="alert-dialog-slide-title"
                            aria-describedby="alert-dialog-slide-description"
                        >
                            <DialogTitle id="alert-dialog-slide-title">{"Cancel registered task?"}</DialogTitle>
                            <DialogContent>
                                <DialogContentText id="alert-dialog-slide-description">
                                    By canceling a registered task you remove it from the tasks list
          </DialogContentText>
                            </DialogContent>
                            <DialogActions>
                                <Button onClick={handleClose} color="primary">
                                    Disagree
          </Button>
                                <Button onClick={() => { props.handleCloseDelete(props.taskId); handleClose(); }} color="primary">
                                    Agree
          </Button>
                            </DialogActions>
                        </Dialog>
                    </Grid>

                    
                ))}
            </Grid>



        </div>
    );
}

class Tasks extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            tasks: [],
            taskId: 0
        };

        fetch('api/task')
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        tasks: result
                    });
                });

        //this.deleteTask = this.deleteTask.bind(this);
    }

   //this.deleteTask = this.deleteTask.bind(this);

    
    handleCloseDelete = async (id) => {

        fetch('api/task/' + id, { method: 'delete' })
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        tasks: this.state.tasks.filter(x => x.id != result.id)
                    });
                })
    };
    

    /*
    handleCloseDelete = (id) => {

        fetch('api/task/'+id, { method: 'delete' })
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        tasks: result
                    });
                });
    };
    */
    render() {
        return (
            <div>
                <h1>Featherink registered tasks</h1>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <TaskCard
                                    {...this.state}
                                    handleCloseDelete={this.handleCloseDelete}
                                />
                            </Col>
                        </Row>
                    </Col>

                </Row>
            </div>
        );
    }
}

export default Tasks;