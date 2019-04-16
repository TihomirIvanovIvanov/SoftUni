using System;

public class Dough
{
    private const double FlourTypeWhite = 1.5;
    private const double FlourTypeWholegrain = 1;
    private const double BakingTechniqueCrispy = 0.9;
    private const double BakingTechniqueChewy = 1.1;
    private const double BakingTechniqueHomemade = 1;
    private const double EachDoughCalories = 2;

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        private set
        {
            if (value != "white" && value != "wholegrain")
            {
                throw new Exception("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }
    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        private set
        {
            if (value != "crispy" && value != "chewy" && value != "homemade")
            {
                throw new Exception("Invalid baking technique.");
            }
            this.bakingTechnique = value;
        }
    }
    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new Exception("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public double Calories()
    {
        return (EachDoughCalories * this.weight) * FlourTypeCalories() * TypeBakingTechnique();
    }

    private double FlourTypeCalories()
    {
        if (this.flourType == "white")
        {
            return FlourTypeWhite;
        }
        else
        {
            return FlourTypeWholegrain;
        }
    }
    private double TypeBakingTechnique()
    {
        if (this.bakingTechnique == "cripsy")
        {
            return BakingTechniqueCrispy;
        }
        else if (this.bakingTechnique == "chewy")
        {
            return BakingTechniqueChewy;
        }
        else
        {
            return BakingTechniqueHomemade;
        }
    }
}