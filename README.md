# Spam Filter Challenge

**Framework:** .NET Core  
**Classifier Used:** SDCLogisticRegression  


## Overview

Spam messages are a common nuisance, cluttering inboxes and posing potential security risks. This project implements a text classification system to distinguish between **spam** and **ham** messages using traditional machine learning techniques.  

The project demonstrates a complete machine learning workflow, from text preprocessing to model training, evaluation, and deployment in a simple interactive interface.

## Features

- **Text Cleaning & Preprocessing:** Removes unnecessary characters, punctuation, and standardizes text for analysis.
- **Vectorization:** Converts text data into numerical features using TF-IDF.
- **Machine Learning Model:** Trains a **SDCLogisticRegression** classifier to distinguish spam from ham.
- **Evaluation Metrics:** Provides detailed model evaluation including:
  - Accuracy
  - Precision
  - Recall
  - F1-score
- **Interactive Tool:** Users can input a message in web application and receive a prediction (`spam` or `ham`).

---

## Installation

1. Clone this repository:

```
git clone https://github.com/yourusername/spam-filter-challenge.git
cd spam-filter-challenge
```

Install the required .NET Core dependencies:
```
dotnet restore
```

Build the project:
```
dotnet build
```
Usage
Command-Line Interface
Run the application:

```
dotnet run
```
Enter a message when prompted, and the model will predict whether it is spam or ham.

Web Interface
Run the application:

```
dotnet run
```
Navigate to http://localhost:5166 in your browser.

Enter a message and receive a real-time prediction.

## Dataset
The project uses a standard spam/ham dataset for training and testing. The dataset includes labeled messages to train the classifier effectively.

# Model Evaluation
The model is evaluated using standard metrics:

```
Metric	Score
Accuracy	98.12%
Precision	96.82%
Recall	89.94%
F1-Score	93.25%
```

<img width="970" height="481" alt="image" src="https://github.com/user-attachments/assets/a3023927-7eae-470e-be99-5e15f52bd9f7" />


<img width="924" height="454" alt="image" src="https://github.com/user-attachments/assets/cf4bc5e1-798d-4a48-9fd4-858e63263d15" />

