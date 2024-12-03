using System;

public class BankruptException : Exception
{
    public BankruptException() : base("Банкрут! Сума грошей не може бути від'ємною.")
    { }
}

public class Money
{
    public int Hryvnias { get; private set; }
    public int Kopecks { get; private set; }

    public Money(int hryvnias, int kopecks)
    {
        if (kopecks >= 100)
        {
            Hryvnias = hryvnias + kopecks / 100;
            Kopecks = kopecks % 100;
        }
        else
        {
            Hryvnias = hryvnias;
            Kopecks = kopecks;
        }
        ValidateNonNegative();
    }

    private void ValidateNonNegative()
    {
        if (Hryvnias < 0 || (Hryvnias == 0 && Kopecks < 0))
        {
            throw new BankruptException();
        }
    }

    public static Money operator +(Money m1, Money m2)
    {
        return new Money(m1.Hryvnias + m2.Hryvnias, m1.Kopecks + m2.Kopecks);
    }

    public static Money operator -(Money m1, Money m2)
    {
        int totalKopecks1 = m1.Hryvnias * 100 + m1.Kopecks;
        int totalKopecks2 = m2.Hryvnias * 100 + m2.Kopecks;

        return new Money(0, totalKopecks1 - totalKopecks2);
    }

    public static Money operator *(Money m, int multiplier)
    {
        return new Money(m.Hryvnias * multiplier, m.Kopecks * multiplier);
    }

    public static Money operator /(Money m, int divisor)
    {
        int totalKopecks = (m.Hryvnias * 100 + m.Kopecks) / divisor;
        return new Money(0, totalKopecks);
    }

    public static Money operator ++(Money m)
    {
        return new Money(m.Hryvnias, m.Kopecks + 1);
    }

    public static Money operator --(Money m)
    {
        return new Money(m.Hryvnias, m.Kopecks - 1);
    }

    public static bool operator <(Money m1, Money m2)
    {
        return m1.Hryvnias * 100 + m1.Kopecks < m2.Hryvnias * 100 + m2.Kopecks;
    }

    public static bool operator >(Money m1, Money m2)
    {
        return m1.Hryvnias * 100 + m1.Kopecks > m2.Hryvnias * 100 + m2.Kopecks;
    }

    public static bool operator ==(Money m1, Money m2)
    {
        return m1.Hryvnias == m2.Hryvnias && m1.Kopecks == m2.Kopecks;
    }

    public static bool operator !=(Money m1, Money m2)
    {
        return !(m1 == m2);
    }

    public override string ToString()
    {
        return $"{Hryvnias} грн {Kopecks} коп.";
    }

    public override bool Equals(object obj)
    {
        if (obj is Money money)
        {
            return this == money;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hryvnias, Kopecks);
    }
}
