using System;
[Serializable]
public class GhostData
{
    //Position
    public double pos_x;
    public double pos_y;
    public double pos_z;

    //Rotation
    public double rot_x;
    public double rot_y;
    public double rot_z;

    public GhostData(double pos_x_, double pos_y_, double pos_z_, double rot_x_, double rot_y_, double rot_z_)
    {
        pos_x = pos_x_;
        pos_y = pos_y_;
        pos_z = pos_z_;
        rot_x = rot_x_;
        rot_y = rot_y_;
        rot_z = rot_z_;
    }
    public override string ToString() => $"({pos_x}, {pos_y}, {pos_z}, {rot_x}, {rot_y}, {rot_z})";
}