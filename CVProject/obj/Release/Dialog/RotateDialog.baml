   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  #    CVProject.Dialog.RotateDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Rotate��$��94��$	��300�����	#FF363636 � WindowStartupLocation$ CenterScreen=�.��� .+��� -    ��Name$ label��$��Degree��$
��Left=�$��	10,12,0,0q�$	��Top=�%  Xceed.Wpf.Toolkit.DecimalUpDown  -   $��degree��$
��Left=�$��	90,10,0,0q�$	��Top=�$��60���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$	 360X�   Minimum$ 0X��� -   $ label_Copy1��$��Resize Mode��$
��Left=�$��9,37,0,0q�$	��Top=��� -    ��Name$ cboxMode��$
��Left=�$��	87,35,0,0q�$	��Top=�$��60�� �� SelectedIndex$ 0��.@��� $��Nearest���� $��Linear���� -    ��Name$ 	btnCancel��$��Cancel��$
��Left=�$��
207,35,0,0q�$	��Top=�$��75���� -   $ btnOK��$��OK��$
��Left=�$��
207,10,0,0q�$	��Top=�$��75���� -   $ 
label_Copy��$��°��$
��Left=�$��
155,12,0,0q�$	��Top=�