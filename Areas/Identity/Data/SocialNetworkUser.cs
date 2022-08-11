﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SocialNetworkUser class
public class SocialNetworkUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    [PersonalData]
    public DateTime DOB { get; set; }

    [PersonalData]
    public string? AvatarPath { get; set; }

    [PersonalData]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

